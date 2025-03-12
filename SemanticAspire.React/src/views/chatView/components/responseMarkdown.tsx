import * as React from 'react';
import Markdown from 'react-markdown';
import rehypeExternalLinks from 'rehype-external-links';
import type { ResponseElement } from '@/shared/models/chat';

export interface ResponseMarkdownProps {
    responseElement: ResponseElement;
}
export const ResponseMarkdown: React.FC<ResponseMarkdownProps> = ({ responseElement }) => {
    if (!responseElement.text) {
        return <></>;
    }

    return <Markdown rehypePlugins={[[rehypeExternalLinks, { target: '_blank' }]]}>{responseElement.text}</Markdown>;
};
