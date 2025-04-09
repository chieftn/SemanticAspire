import React from 'react';
import { createFileRoute } from '@tanstack/react-router';
import { useResponseCache } from '@/shared/hooks/useResponseCache';
import { ResponseChart } from '@/views/chatView/components/responseChart';
import { ResponseGraph } from '@/views/chatView/components/responseGraph';
import { ResponseMarkdown } from '@/views/chatView/components/responseMarkdown';
import { ResponseTable } from '@/views/chatView/components/responseTable';
import { ViewLayout } from '@/shared/components/viewLayout';

export const Route = createFileRoute('/responseCache')({
    component: RouteComponent,
});

function RouteComponent() {
    const responses = useResponseCache();

    return (
        <ViewLayout
            body={responses.values.map((s) => (
                <div style={{ margin: 20 }}>
                    <div>{s.name || 'NA'}</div>
                    <div>
                        {s.response.map((element) => (
                            <>
                                <ResponseMarkdown responseElement={element} />
                                <ResponseChart responseElement={element} />
                                <ResponseGraph responseElement={element} />
                                <ResponseTable responseElement={element} />
                            </>
                        ))}
                    </div>
                </div>
            ))}
        />
    );
}
