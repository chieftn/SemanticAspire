import * as React from 'react';
import type { Prompt } from '@/shared/models/chat';
import { makeStyles, tokens } from '@fluentui/react-components';
import { ChatResponse } from './chatRresponse';

export const useStyles = makeStyles({
    rootStyle: {
        display: 'flex',
        flexDirection: 'column',
        gap: tokens.spacingVerticalL,
        marginBlockEnd: tokens.spacingVerticalXXXL,
    },
    promptStyle: {
        display: 'inline-flex',
        flexDirection: 'row-reverse',
    },
    promptTextStyle: {
        backgroundColor: tokens.colorBrandBackgroundInvertedSelected,
        borderRadius: tokens.borderRadiusMedium,
        paddingInline: tokens.spacingHorizontalS,
        paddingBlock: tokens.spacingVerticalS,
    },
});

export interface ChatInteractionProps {
    prompt: Prompt;
}
export const ChatInteraction: React.FC<ChatInteractionProps> = ({ prompt }) => {
    const { rootStyle, promptStyle, promptTextStyle } = useStyles();
    const { text } = prompt;
    const scrollToRef = React.useRef<HTMLDivElement>(null);

    React.useEffect(() => {
        if (scrollToRef.current) {
            scrollToRef.current?.scrollIntoView();
        }
    }, []);

    return (
        <div className={rootStyle} ref={scrollToRef}>
            <div className={promptStyle}>
                <div className={promptTextStyle}>{text}</div>
            </div>
            <ChatResponse prompt={prompt} />
        </div>
    );
};
