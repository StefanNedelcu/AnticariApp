import React, { useRef, useState } from 'react';
import { Link, useHistory } from "react-router-dom";
import { Container, Row, Col, Alert, Form, Button } from 'react-bootstrap';
import axiosInstance from "../../config/Axios";

import './Auth.css';

const Login = () => {
    const emailRef = useRef();
    const passwordRef = useRef();
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);
    const history = useHistory();
   
    function handleLogIn(e) {
        e.preventDefault()
        handleSubmit(e);
    }

    async function handleSubmit(e) {
        e.preventDefault()

        setError("");
        setLoading(true);

        await axiosInstance.post('auth', { 
                email: emailRef.current.value, 
                password: passwordRef.current.value 
            })
            .then(({ data }) => {
                localStorage.setItem('currentUser', data);
                history.push('/');
            })
            .catch((error) => { 
                setError(error.response.data.message)
            })
            .finally(() => setLoading(false));
    }

    return (
        <Row className='full-height'>
            <Col xs={3} className='side-panel'>
                <div style={{height: '70%'}} className='d-flex flex-column justify-content-around'>
                    <h1>AnticariApp</h1>

                    <h3>Cumpără sau postează propriile anunțuri de vânzare sau schimb de cărți chiar acum!</h3>
                </div>                
            </Col>

            <Col xs={9}>
                <Container className='mt-4'>
                    <h2 className='py-5'>Loghează-te</h2>
                    <h5 className='py-3'>Te rugăm să îți introduci datele de conectare.</h5>
                    <hr/>

                    {error && <Alert variant="danger">{error}</Alert>}

                    <Form onSubmit={handleLogIn}>
                        <Form.Group id="email" className='mt-2'>
                            <Form.Label>Email</Form.Label>
                            <Form.Control type="email" ref={emailRef} required />
                        </Form.Group>

                        <Form.Group id="password" className='mt-3'>
                            <Form.Label>Parolă</Form.Label>
                            <Form.Control type="password" ref={passwordRef} required />
                        </Form.Group>

                        <Button variant='primary' disabled={loading} type="submit" className='mt-3'>
                            Login
                        </Button>
                    </Form>

                    <div className="w-100 mt-2">
                        Nu ai încă un cont? <Link to="/register">Înregistrează-te.</Link>
                    </div>

                </Container>
            </Col>
        </Row>
    );
}

export default Login;
