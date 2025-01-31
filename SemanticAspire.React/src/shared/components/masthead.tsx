import * as React from 'react';
import { makeStyles, tokens } from '@fluentui/react-components';
import { Navigation } from './navigation';

export const useStyles = makeStyles({
    rootStyle: {
        backgroundColor: tokens.colorBrandBackground,
        color: tokens.colorNeutralBackground1,
        paddingBlock: tokens.spacingVerticalXS,
        display: 'flex',
        padding: 0,
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
            <Navigation />
            <h1 className={titleStyle}>Azure IoT Operations</h1>
        </div>
    );
};
