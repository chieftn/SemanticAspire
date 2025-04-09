import * as React from 'react';
import { PreviewLink20Filled, PreviewLink20Regular, bundleIcon } from '@fluentui/react-icons';
import { useId, Button, Popover, PopoverTrigger, PopoverSurface, Input, Field } from '@fluentui/react-components';
import type { PopoverProps, InputProps } from '@fluentui/react-components';

const PerformanceReviews = bundleIcon(PreviewLink20Filled, PreviewLink20Regular);

export interface RetainButtonProps {
    onRetain(name: string): void;
}
export const RetainButton: React.FC<RetainButtonProps> = ({ onRetain }) => {
    const [open, setOpen] = React.useState<boolean>(false);
    const [name, setName] = React.useState<string>('');
    const id = useId();

    const handleOpenChange: PopoverProps['onOpenChange'] = (e, data) => {
        setOpen(data.open || false);
    };

    const onNameChange: InputProps['onChange'] = (ev, data) => {
        setName(data.value);
    };

    const onSubmit = (): void => {
        onRetain(name);
        setOpen(false);
    };

    return (
        <Popover open={open} onOpenChange={handleOpenChange} trapFocus>
            <PopoverTrigger disableButtonEnhancement>
                <Button icon={<PerformanceReviews />}>Retain</Button>
            </PopoverTrigger>

            <PopoverSurface aria-labelledby={id}>
                <div>
                    <Field id={id} label="Name:">
                        <Input value={name} onChange={onNameChange} />
                    </Field>
                    <div>
                        <Button onClick={onSubmit}>OK</Button>
                        <Button onClick={() => setOpen(false)}>Cancel</Button>
                    </div>
                </div>
            </PopoverSurface>
        </Popover>
    );
};
