import * as React from 'react';
import { ViewLayout } from '@/shared/components/viewLayout';
import { UserPrompt } from './components/userPrompt';
import { UserInteractions } from './components/userInteractions';

export const ChatView: React.FC = () => {
    return <ViewLayout body={<UserInteractions />} footer={<UserPrompt />} />;
};
