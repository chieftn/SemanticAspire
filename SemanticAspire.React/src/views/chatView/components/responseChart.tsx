import * as React from 'react';
import type { ResponseElement } from '@/shared/models/chat';

export interface ResponseChartProps {
    responseElement: ResponseElement;
}
export const ResponseChart: React.FC<ResponseChartProps> = ({ responseElement }) => {
    if (!responseElement.chart) {
        return <></>;
    }

    return <div>Format Chart</div>;
};
