import * as React from 'react';
import { Button, Input, makeStyles, type InputProps } from '@fluentui/react-components';
import { Send24Regular } from '@fluentui/react-icons';

export const useStyles = makeStyles({
    rootStyle: {
        display: 'flex',
        justifyContent: 'center',
    },
    promptStyle: {
        display: 'flex',
        flexDirection: 'column',
        flexGrow: 2,
        marginInline: '20%',
    },
});

export interface UserPromptProps {
    onSubmit(value: string): void;
}
export const UserPrompt: React.FC<UserPromptProps> = ({ onSubmit }) => {
    const { rootStyle, promptStyle } = useStyles();
    const [value, setValue] = React.useState<string>('');

    const onChange: InputProps['onChange'] = (ev, data) => {
        setValue(data.value);
    };

    const submit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        onSubmit(value);
        setValue('');
    };

    return (
        <div className={rootStyle}>
            <form className={promptStyle} onSubmit={submit}>
                <Input
                    value={value}
                    onChange={onChange}
                    autoFocus={true}
                    placeholder={'Ask a question'}
                    contentAfter={
                        <Button type="submit" appearance="subtle" icon={<Send24Regular />} disabled={!value} />
                    }
                />
            </form>
        </div>
    );
};
