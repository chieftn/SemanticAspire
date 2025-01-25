import * as React from 'react';

export const App: React.FC = () => {
    React.useEffect(() => {
        const me = async () => {
            const today = await fetch('/api/secrets/', {
            method: 'Get'
        });
        console.log(today);
        };

        me();
    })

    return <div>Hello world 2</div>;
}