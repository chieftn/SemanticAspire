export interface Prompt {
    id: string;
    text: string;
}

export interface ChatInteraction {
    prompt: Prompt;
    response?: string;
}
