import * as React from 'react';
import { createFileRoute } from '@tanstack/react-router';
import { ChatView } from '@/views/chatView/chatView';

export const Route = createFileRoute('/incidentAgent')({
    component: RouteComponent,
});

function RouteComponent() {
    return <ChatView key={'incident'} endpoint={'incident'} />;
}
