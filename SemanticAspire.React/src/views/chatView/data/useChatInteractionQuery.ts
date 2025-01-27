import { useQuery } from '@tanstack/react-query';
import type { Prompt, ChatInteraction } from '@/shared/models/chat';
import { postPrompt } from '@/shared/services/chatService';

export const useChatInteractionQuery = (prompt: Prompt) => {
    const result = useQuery<ChatInteraction>({
        queryKey: ['chatInteraction', prompt.id],
        queryFn: () => postPrompt(prompt),
    });

    return result;
};
