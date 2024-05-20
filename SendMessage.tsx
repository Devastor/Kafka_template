
import React, { useState } from 'react';
import axios from 'axios';

const SendMessage: React.FC = () => {
    const [message, setMessage] = useState('');

    const handleSendMessage = async () => {
        await axios.post('http://localhost:5000/api/messages', { content: message });
        setMessage('');
    };

    return (
        <div>
            <input 
                type="text" 
                value={message} 
                onChange={(e) => setMessage(e.target.value)} 
                placeholder="Enter your message" 
            />
            <button onClick={handleSendMessage}>Send</button>
        </div>
    );
};

export default SendMessage;
