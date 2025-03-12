import * as React from 'react';
import { makeStyles, tokens } from '@fluentui/react-components';
import type { Prompt } from '@/shared/models/chat';
import { useChatInteractionQuery } from '../data/useChatInteractionQuery';
import { ChatResponseError } from './chatResponseError';
import { ChatResponsePending } from './chatResponsePending';
import { ResponseChart } from './responseChart';
import { ResponseGraph } from './responseGraph';
import { ResponseMarkdown } from './responseMarkdown';
import { ResponseTable } from './responseTable';

export const useStyles = makeStyles({
    rootStyle: {
        maxWidth: '100%',
        overflowY: 'auto',
    },
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
                {status === 'success' &&
                    data.map((element) => (
                        <>
                            <ResponseMarkdown responseElement={element} />
                            <ResponseChart responseElement={element} />
                            <ResponseGraph responseElement={element} />
                            <ResponseTable responseElement={element} />
                        </>
                    ))}
            </div>
        </div>
    );
};
