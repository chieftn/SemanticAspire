import * as React from 'react';
import { makeStyles, tokens } from '@fluentui/react-components';

export const useStyles = makeStyles({
    rootStyle: {
        backgroundColor: tokens.colorBrandBackground,
        color: tokens.colorNeutralBackground1,
        paddingBlock: tokens.spacingVerticalXS,
    },
    titleStyle: {
        marginInlineStart: tokens.spacingHorizontalS,
        fontSize: tokens.fontSizeBase500,
        fontWeight: tokens.fontWeightMedium,
    },
});

export const Masthead: React.FC = () => {
    const { rootStyle, titleStyle } = useStyles();

    return (
        <div className={rootStyle}>
            <h1 className={titleStyle}>Azure IoT Operations</h1>
        </div>
    );
};
