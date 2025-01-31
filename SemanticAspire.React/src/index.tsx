import * as React from 'react';
import { createRoot } from 'react-dom/client';
import { FluentProvider, webLightTheme } from '@fluentui/react-components';
import { ReactQueryDevtools } from '@tanstack/react-query-devtools';
import { QueryClientProvider } from '@tanstack/react-query';
import { RouterProvider } from '@tanstack/react-router';
import { getQueryClient } from '@/shared/utils/queryClientHelper';
import { getRouter } from '@/shared/utils/routerHelper';

const domNode = document.getElementById('root');
const root = createRoot(domNode!);
const queryClient = getQueryClient();
const router = getRouter();

declare module '@tanstack/react-router' {
    interface Register {
        router: typeof router;
    }
}

root.render(
    <React.StrictMode>
        <QueryClientProvider client={queryClient}>
            <FluentProvider theme={webLightTheme}>
                <RouterProvider router={router} />
            </FluentProvider>
            <ReactQueryDevtools />
        </QueryClientProvider>
    </React.StrictMode>
);
