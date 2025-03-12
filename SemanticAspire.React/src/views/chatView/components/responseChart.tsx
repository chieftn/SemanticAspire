import * as React from 'react';
import { Chart, AxisOptions } from 'react-charts';
import type { ResponseElement, ChartDatum } from '@/shared/models/chat';

export interface ResponseChartProps {
    responseElement: ResponseElement;
}
export const ResponseChart: React.FC<ResponseChartProps> = ({ responseElement }) => {
    const primaryAxis = React.useMemo(
        (): AxisOptions<ChartDatum> => ({
            getValue: (datum) => datum.x,
        }),
        []
    );

    const secondaryAxes = React.useMemo(
        (): AxisOptions<ChartDatum>[] => [
            {
                getValue: (datum) => datum.y,
            },
        ],
        []
    );

    if (!responseElement.chart) {
        return <></>;
    }

    return (
        <div style={{ width: '800px', height: '400px' }}>
            <Chart
                options={{
                    data: responseElement.chart,
                    primaryAxis,
                    secondaryAxes,
                }}
            />
        </div>
    );
};
