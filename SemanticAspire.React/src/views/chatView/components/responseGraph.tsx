import * as React from 'react';
import type { ResponseElement } from '@/shared/models/chat';

export interface ResponseGraphProps {
    responseElement: ResponseElement;
}
export const ResponseGraph: React.FC<ResponseGraphProps> = ({ responseElement }) => {
    if (!responseElement.graph) {
        return <></>;
    }

    return <div>Format Graph</div>;
};
