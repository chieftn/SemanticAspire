import { z } from 'zod';

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

const graphSchema = z.object({});
const chartSchema = z.object({});
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
