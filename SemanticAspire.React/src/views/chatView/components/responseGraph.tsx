import * as React from 'react';
import { ReactFlow, ConnectionLineType, Background } from '@xyflow/react';
import type { ResponseElement } from '@/shared/models/chat';
import '@xyflow/react/dist/style.css';

export interface ResponseGraphProps {
    responseElement: ResponseElement;
}
export const ResponseGraph: React.FC<ResponseGraphProps> = ({ responseElement }) => {
    const { graph } = responseElement;

    if (!graph) {
        return <></>;
    }

    const { nodes, edges } = graph;
    return (
        <div style={{ width: '800px', height: '400px' }}>
            <ReactFlow
                nodes={nodes}
                edges={edges}
                connectionLineType={ConnectionLineType.SmoothStep}
                fitView={true}
                style={{ backgroundColor: '#F7F9FB' }}
            >
                <Background />
            </ReactFlow>
        </div>
    );
};
