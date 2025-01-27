import * as React from 'react';

export interface ChatResponseErrorProps {
    error?: unknown;
}
export const ChatResponseError: React.FC<ChatResponseErrorProps> = ({ error }) => {
    return <div>Uh oh - a problem occurred</div>;
};
