
import React from 'react';
import SendMessage from './SendMessage';
import ReceiveMessages from './ReceiveMessages';

const App: React.FC = () => {
    return (
        <div>
            <h1>Message App</h1>
            <SendMessage />
            <ReceiveMessages />
        </div>
    );
};

export default App;
