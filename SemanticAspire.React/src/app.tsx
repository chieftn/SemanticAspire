import * as React from 'react';
import { FluentProvider, webLightTheme } from '@fluentui/react-components';
import { ReactQueryDevtools } from '@tanstack/react-query-devtools';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { RouterProvider, createRouter } from '@tanstack/react-router';
import { routeTree } from './routeTree.gen';

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

// Create a new router instance
const router = createRouter({ routeTree });

// Register the router instance for type safety
declare module '@tanstack/react-router' {
    interface Register {
        router: typeof router;
    }
}

export const App: React.FC = () => {
    return (
        <QueryClientProvider client={queryClient}>
            <FluentProvider theme={webLightTheme}>
                <RouterProvider router={router} />
            </FluentProvider>
            <ReactQueryDevtools />
        </QueryClientProvider>
    );
};
