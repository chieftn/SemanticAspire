import type { ChatResponse } from '../models/chat';
import { useStateCache } from './useStateCache';

export interface ResponseCacheEntry {
    name?: string;
    response: ChatResponse;
}

export interface ResponseCache {
    responses: ResponseCacheEntry[];
    addResponse(response: string): void;
}
export const useResponseCache = () => {
    const [values, setValues] = useStateCache<ResponseCacheEntry[]>({ cacheKeyName: 'responses' }, []);
    const addResponse = (response: ChatResponse, name: string = '') => {
        setValues([...values, { response, name }]);
    };

    return {
        values,
        addResponse,
    };
};
