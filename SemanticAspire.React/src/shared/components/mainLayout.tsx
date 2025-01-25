import * as React from 'react';

export interface MainLayoutProps {
    header?: React.ReactNode;
    navigation?: React.ReactNode;
    body: React.ReactNode;
    footer?: React.ReactNode;
}
export const MainLayout: React.FC<MainLayoutProps> = (props) => {
    const { header, navigation, body, footer } = props;

    return (
        <>
        {header && <header>{header}</header>}
        {navigation && <nav>{navigation}</nav>}
        <main>
            {body}
        </main>

        {footer && <footer>{footer}</footer>}
        </>

    )





};