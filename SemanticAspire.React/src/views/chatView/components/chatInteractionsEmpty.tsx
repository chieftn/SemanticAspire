import * as React from 'react';
import { makeStyles } from '@fluentui/react-components';
import { AddItemIcon } from '@/shared/components/addItemIcon';

export const useStyles = makeStyles({
    rootStyle: {
        alignContent: 'center',
        height: '100%',
        margin: 'auto',
        textAlign: 'center',
    },
});
export const ChatInteractionsEmpty: React.FC = () => {
    const { rootStyle } = useStyles();

    return (
        <div className={rootStyle}>
            <AddItemIcon />
            <div>Ask a question</div>
        </div>
    );
};
