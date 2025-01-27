import * as React from 'react';
import { makeStyles } from '@fluentui/react-components';
import type { Prompt } from '@/shared/models/chat';
import { ChatInteraction } from './chatInteraction';

export const useStyles = makeStyles({
    rootStyle: {
        paddingInline: '20%',
    },
});

export interface ChatInteractionsProps {
    prompts: Prompt[];
}
export const ChatInteractions: React.FC<ChatInteractionsProps> = ({ prompts }) => {
    const { rootStyle } = useStyles();

    return (
        <div className={rootStyle}>
            {prompts.map((prompt) => (
                <ChatInteraction key={prompt.id} prompt={prompt} />
            ))}
        </div>
    );
};
