export interface Prompt {
    endpoint?: string;
    sessionId: string;
    id: string;
    text: string;
}

export interface ChatInteraction {
    prompt: string;
    response: string;
}
