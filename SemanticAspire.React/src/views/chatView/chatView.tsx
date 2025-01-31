import * as React from 'react';
import type { Prompt } from '@/shared/models/chat';
import { ViewLayout } from '@/shared/components/viewLayout';
import { useStateCache } from '@/shared/hooks/useStateCache';
import { getUUID } from '@/shared/utils/cryptoHelper';
import { UserPrompt } from './components/userPrompt';
import { ChatInteractions } from './components/chatInteractions';

export interface ChatViewProps {
    endpoint?: string;
}
export const ChatView: React.FC<ChatViewProps> = ({ endpoint }) => {
    const [sessionId] = useStateCache<string>({ cacheKeyName: `sessionId_${endpoint || ''}` }, getUUID());
    const [prompts, setPrompts] = useStateCache<Prompt[]>({ cacheKeyName: `prompts_${sessionId}` }, []);

    const onPrompt = (value: string) => {
        const prompt = {
            endpoint,
            sessionId,
            id: getUUID(),
            text: value,
        };

        setPrompts([...prompts, prompt]);
    };

    return <ViewLayout body={<ChatInteractions prompts={prompts} />} footer={<UserPrompt onSubmit={onPrompt} />} />;
};
