import * as React from 'react';
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
        borderRadius: tokens.borderRadiusSmall,
        paddingInline: tokens.spacingHorizontalS,
        paddingBlock: tokens.spacingVerticalS,
    },
    responseStyle: {},
});

export const UserInteraction: React.FC = () => {
    const { rootStyle, promptStyle, promptTextStyle, responseStyle } = useStyles();
    return (
        <div className={rootStyle}>
            <div className={promptStyle}>
                <div className={promptTextStyle}>prompt</div>
            </div>
            <div className={responseStyle}>response</div>
        </div>
    );
};
