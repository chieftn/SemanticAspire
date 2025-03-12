import { z } from 'zod';
import { Position, type Node, type Edge } from '@xyflow/react';
import dagre from '@dagrejs/dagre';

const dagreGraph = new dagre.graphlib.Graph().setDefaultEdgeLabel(() => ({}));
const nodeWidth = 172;
const nodeHeight = 36;

export interface Prompt {
    endpoint?: string;
    sessionId: string;
    id: string;
    text: string;
}

export interface ChatInteraction {
    prompt: string;
    response?: string;
}

const graphSchema = z
    .object({
        nodes: z.array(
            z.object({
                id: z.number(),
                name: z.string(),
            })
        ),
        edges: z.array(
            z.object({
                name: z.string(),
                source: z.number(),
                target: z.number(),
            })
        ),
    })
    .transform(({ nodes, edges }) => {
        dagreGraph.setGraph({ rankdir: 'vertical' });

        nodes.forEach((node) => {
            dagreGraph.setNode(node.id.toString(), { width: nodeWidth, height: nodeHeight });
        });

        edges.forEach((edge) => {
            dagreGraph.setEdge(edge.source.toString(), edge.target.toString());
        });

        dagre.layout(dagreGraph);

        const newNodes: Node[] = nodes.map((node, i) => {
            const nodeWithPosition = dagreGraph.node(node.id.toString());
            const newNode = {
                id: node.id.toString(),
                targetPosition: Position.Top,
                sourcePosition: Position.Bottom,
                position: {
                    x: nodeWithPosition.x - nodeWidth / 2,
                    y: nodeWithPosition.y - nodeHeight / 2,
                },
                data: { label: node.name },
            };

            return newNode;
        });

        const newEdges: Edge[] = edges.map((edge, i) => ({
            id: i.toString(),
            label: edge.name,
            target: edge.target.toString(),
            source: edge.source.toString(),
        }));

        return { nodes: newNodes, edges: newEdges };
    });

const chartDatumSchema = z.object({
    x: z.string().or(z.number()),
    y: z.string().or(z.number()),
});

const chartSchema = z.array(
    z.object({
        label: z.string(),
        data: z.array(chartDatumSchema),
    })
);

const tableSchema = z.object({
    headers: z.array(z.string()),
    rows: z.array(z.record(z.string(), z.string().or(z.number()))),
});

const textSchema = z.string();

const responseElementSchema = z.object({
    chart: chartSchema.optional(),
    graph: graphSchema.optional(),
    table: tableSchema.optional(),
    text: textSchema.optional(),
});

const chatResponseSchema = z.array(responseElementSchema);

export type ResponseElement = z.infer<typeof responseElementSchema>;
export type ChatResponse = z.infer<typeof chatResponseSchema>;
export type Graph = z.infer<typeof graphSchema>;
export type Table = z.infer<typeof tableSchema>;
export type Text = z.infer<typeof textSchema>;
export type Chart = z.infer<typeof chartSchema>;
export type ChartDatum = z.infer<typeof chartDatumSchema>;

export const parseChatResponse = (response?: string): ChatResponse => {
    try {
        if (!response) {
            return [{ text: '' }];
        }

        const responseObject = JSON.parse(response);
        const responseParsed = responseElementSchema.parse(responseObject);

        return [responseParsed];
    } catch (e) {
        console.log(e);
        return [{ text: response }];
    }
};
