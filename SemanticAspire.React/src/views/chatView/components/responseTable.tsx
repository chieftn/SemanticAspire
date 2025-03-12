import * as React from 'react';
import type { ResponseElement } from '@/shared/models/chat';

export interface ResponseTableProps {
    responseElement: ResponseElement;
}
export const ResponseTable: React.FC<ResponseTableProps> = ({ responseElement }) => {
    const { table } = responseElement;

    if (!table) {
        return <></>;
    }

    return (
        <table>
            <thead>
                <tr>
                    {table.headers.map((h) => (
                        <th>{h}</th>
                    ))}
                </tr>
            </thead>
            <tbody>
                {table.rows.map((r) => (
                    <tr>
                        {table.headers.map((h) => (
                            <td>{r[h] || 'NA'}</td>
                        ))}
                    </tr>
                ))}
            </tbody>
        </table>
    );
};
