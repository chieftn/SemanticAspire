import * as React from 'react';
import { Field, ProgressBar } from '@fluentui/react-components';

export const ChatResponsePending: React.FC = () => {
    return (
        <Field validationMessage="Working on it" validationState="none">
            <ProgressBar />
        </Field>
    );
};
