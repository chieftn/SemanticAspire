import { MIME_TYPES, HTTP_OPERATIONS } from '../utils/serviceHelper';
import type { Prompt, ChatInteraction } from '../models/chat';

export const postPrompt = async (prompt: Prompt): Promise<ChatInteraction> => {
    const response = await fetch('/api/chat/', {
        body: JSON.stringify({ prompt: prompt.text, sessionId: prompt.sessionId }),
        headers: new Headers({
            Accept: MIME_TYPES.APPLICATION_JSON,
            'Content-Type': MIME_TYPES.APPLICATION_JSON,
        }),
        method: HTTP_OPERATIONS.POST,
    });

    if (!response.ok) {
        throw response;
    }

    const responseBody = (await response.json()) as ChatInteraction;
    return responseBody;
};
