import * as React from 'react';
import { makeStyles, tokens } from '@fluentui/react-components';

export const useStyles = makeStyles({
    rootStyle: {
        display: 'flex',
        height: '100vh',
        flexDirection: 'column',
    },

    centerStyle: {
        flexGrow: 3,
        height: '100%',
        overflow: 'auto',
        display: 'flex',
        flexDirection: 'row',
        width: '100%',
        gap: tokens.spacingVerticalL,
        marginBlockEnd: tokens.spacingVerticalM,
    },

    mainStyle: {
        flexGrow: 3,
    },
});

export interface MainLayoutProps {
    header?: React.ReactNode;
    navigation?: React.ReactNode;
    body: React.ReactNode;
    footer?: React.ReactNode;
}
export const MainLayout: React.FC<MainLayoutProps> = (props) => {
    const { header, navigation, body, footer } = props;
    const { rootStyle, centerStyle, mainStyle } = useStyles();

    return (
        <div className={rootStyle}>
            {header && <header>{header}</header>}
            <div className={centerStyle}>
                {navigation && <nav>{navigation}</nav>}
                <main className={mainStyle}>{body}</main>
            </div>

            {footer && <footer>{footer}</footer>}
        </div>
    );
};
