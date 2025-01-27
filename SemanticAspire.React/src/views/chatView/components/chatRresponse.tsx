import * as React from 'react';
import { makeStyles, tokens } from '@fluentui/react-components';
import type { Prompt } from '@/shared/models/chat';
import { useChatInteractionQuery } from '../data/useChatInteractionQuery';
import { ChatResponseError } from './chatResponseError';
import { ChatResponsePending } from './chatResponsePending';

export const useStyles = makeStyles({
    rootStyle: {},
    nameStyle: {
        fontWeight: tokens.fontWeightSemibold,
        marginBlockEnd: tokens.spacingVerticalM,
    },
});

export interface ChatResponseProps {
    prompt: Prompt;
}
export const ChatResponse: React.FC<ChatResponseProps> = ({ prompt }) => {
    const { rootStyle, nameStyle } = useStyles();
    const { data, status } = useChatInteractionQuery(prompt);

    return (
        <div className={rootStyle}>
            <div className={nameStyle}>IoT Operations Assistant</div>
            <div>
                {status === 'error' && <ChatResponseError />}
                {status === 'pending' && <ChatResponsePending />}
                {status === 'success' && <div>{data?.response}</div>}
            </div>
        </div>
    );
};
