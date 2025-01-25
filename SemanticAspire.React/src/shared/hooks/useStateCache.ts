import { useCallback } from 'react';
import { useQueryClient, useQuery } from '@tanstack/react-query';

// Necessary to cast placeholder data.
// eslint-disable-next-line @typescript-eslint/ban-types
export type NonFunctionGuard<T> = T extends Function ? never : T;
export type CacheInterface<T> = [T, (value: T) => void];

export const useStateCache = <T>(parameters: CacheParameters, defaultValue: T): CacheInterface<T> => {
    const [getCacheValue, setCacheValue] = useStateCacheManager<T>(parameters);

    const { data } = useQuery<T>({
        queryKey: getQueryKey(parameters),
        queryFn: () => getCacheValue() || defaultValue,
        placeholderData: (getCacheValue() || defaultValue) as NonFunctionGuard<T>,
        staleTime: Infinity,
        gcTime: Infinity,
    });

    const onSetValue = (value: T) => {
        setCacheValue(value);
    };

    return [data || defaultValue, onSetValue];
};

// lower level hook for use when reactivity is not necessary.
export const useStateCacheManager = <T>(parameters: CacheParameters): [() => T | undefined, (value: T) => void] => {
    const queryClient = useQueryClient();

    const onGetValue = useCallback(
        (): T | undefined => queryClient.getQueryData<T | undefined>(getQueryKey(parameters)),
        [queryClient, parameters]
    );

    const onSetValue = useCallback(
        (value: T) => queryClient.setQueryData(getQueryKey(parameters), value),
        [queryClient, parameters]
    );

    return [onGetValue, onSetValue];
};

export const SYNC_KEY = 'sync';
export const getQueryKey = (parameters: CacheParameters): string[] => [SYNC_KEY, parameters.cacheKeyName];

export interface CacheParameters {
    cacheKeyName: string;
}
