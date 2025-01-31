import { QueryClient } from '@tanstack/react-query';

export const getQueryClient = () =>
    new QueryClient({
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
