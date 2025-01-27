import * as React from 'react';
import { makeStyles, tokens } from '@fluentui/react-components';

export const useStyles = makeStyles({
    rootStyle: {
        height: '100%',
        width: '100%',
        display: 'flex',
        flexDirection: 'column',
        gap: tokens.spacingVerticalL,
    },
    bodyStyle: {
        flexGrow: 4,
        overflowY: 'auto',
    },
});

export interface ViewLayoutProps {
    header?: React.ReactNode;
    body: React.ReactNode;
    footer?: React.ReactNode;
}
export const ViewLayout: React.FC<ViewLayoutProps> = (props) => {
    const { header, body, footer } = props;
    const { rootStyle, bodyStyle } = useStyles();

    return (
        <div className={rootStyle}>
            {header && <div>{header}</div>}
            <div className={bodyStyle}>{body}</div>
            {footer && <div>{footer}</div>}
        </div>
    );
};
