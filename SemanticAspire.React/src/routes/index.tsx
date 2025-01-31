import * as React from 'react';
import { createFileRoute } from '@tanstack/react-router';
import { ChatView } from '@/views/chatView/chatView';

export const Route = createFileRoute('/')({
    component: RouteComponent,
});

function RouteComponent() {
    return <ChatView key={'chat'} />;
}
