import * as React from 'react';
import { makeStyles, tokens } from '@fluentui/react-components';
import type { Prompt } from '@/shared/models/chat';
import { ChatInteraction } from './chatInteraction';
import { ChatInteractionsEmpty } from './chatInteractionsEmpty';

export const useStyles = makeStyles({
    rootStyle: {
        marginBlockStart: tokens.spacingVerticalM,
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
            {prompts.length === 0 && <ChatInteractionsEmpty />}
        </div>
    );
};
