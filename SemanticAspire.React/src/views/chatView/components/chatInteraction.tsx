import * as React from 'react';
import type { Prompt } from '@/shared/models/chat';
import { makeStyles, tokens } from '@fluentui/react-components';

export const useStyles = makeStyles({
    rootStyle: {
        display: 'flex',
        flexDirection: 'column',
        gap: tokens.spacingVerticalS,
        marginBlockEnd: tokens.spacingVerticalM,
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
    responseStyle: {},
});

export interface ChatInteractionProps {
    prompt: Prompt;
}
export const ChatInteraction: React.FC<ChatInteractionProps> = ({ prompt }) => {
    const { rootStyle, promptStyle, promptTextStyle, responseStyle } = useStyles();
    const { text } = prompt;

    return (
        <div className={rootStyle}>
            <div className={promptStyle}>
                <div className={promptTextStyle}>{text}</div>
            </div>
            <div className={responseStyle}>response</div>
        </div>
    );
};
