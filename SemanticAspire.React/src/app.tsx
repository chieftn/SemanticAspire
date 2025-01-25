import * as React from 'react';
import { FluentProvider, webLightTheme } from '@fluentui/react-components';
import { ReactQueryDevtools } from '@tanstack/react-query-devtools';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { MainLayout } from '@/shared/components/mainLayout';
import { Masthead } from '@/shared/components/masthead';
import { Footer } from '@/shared/components/footer';
import { ChatView } from '@/views/chatView/chatView';

const queryClient = new QueryClient({
    defaultOptions: {
        queries: {
            networkMode: 'always',
            refetchOnWindowFocus: false,
            refetchOnMount: false,
            retryOnMount: false,
            retry: false,
        },
    },
});

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
        <QueryClientProvider client={queryClient}>
            <FluentProvider theme={webLightTheme}>
                <MainLayout header={<Masthead />} body={<ChatView />} footer={<Footer />} navigation={<div>Nav</div>} />
            </FluentProvider>
            <ReactQueryDevtools />
        </QueryClientProvider>
    );
};
