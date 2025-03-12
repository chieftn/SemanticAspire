import { useQuery } from '@tanstack/react-query';
import { Prompt, ChatResponse, parseChatResponse } from '@/shared/models/chat';
import { postPrompt } from '@/shared/services/chatService';

export const useChatInteractionQuery = (prompt: Prompt) => {
    const result = useQuery<ChatResponse>({
        queryKey: ['chatInteraction', prompt.id],
        queryFn: async () => {
            const response = await postPrompt(prompt);
            return parseChatResponse(response.response);
        },
    });

    return result;
};
