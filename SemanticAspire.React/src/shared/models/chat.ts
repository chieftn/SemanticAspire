export interface Prompt {
    text: string;
}

export interface ChatInteraction {
    prompt: Prompt;
    response?: string;
}
