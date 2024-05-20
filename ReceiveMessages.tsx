
import React, { useEffect, useState } from 'react';
import axios from 'axios';

const ReceiveMessages: React.FC = () => {
    const [messages, setMessages] = useState<string[]>([]);

    useEffect(() => {
        const fetchMessages = async () => {
            const response = await axios.get('http://localhost:5000/api/messages');
            setMessages(response.data);
        };

        fetchMessages();
    }, []);

    return (
        <div>
            <h3>Messages:</h3>
            <ul>
                {messages.map((msg, index) => (
                    <li key={index}>{msg}</li>
                ))}
            </ul>
        </div>
    );
};

export default ReceiveMessages;
