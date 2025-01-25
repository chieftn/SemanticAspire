import * as React from 'react';
import { FluentProvider, webLightTheme } from '@fluentui/react-components';
import { MainLayout } from '@/shared/components/mainLayout';
import { Masthead } from '@/shared/components/masthead';
import { Footer } from '@/shared/components/footer';
import { ChatView } from '@/views/chatView/chatView';

export const App: React.FC = () => {
    // React.useEffect(() => {
    //     const me = async () => {
    //         const today = await fetch('/api/secrets/', {
    //         method: 'Get'
    //     });
    //     console.log(today);
    //     };

    //     me();
    // })

    return (
        <FluentProvider theme={webLightTheme}>
            <MainLayout header={<Masthead />} body={<ChatView />} footer={<Footer />} navigation={<div>Nav</div>} />
        </FluentProvider>
    );
};
