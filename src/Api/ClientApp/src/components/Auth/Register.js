import React, { useRef, useState } from 'react';
import { Link, useHistory } from "react-router-dom";
import { Container, Row, Col, Alert, Form, Button } from 'react-bootstrap';
import axiosInstance from "../../config/Axios";

const Register = () => {
    const firstNameRef = useRef();
    const lastNameRef = useRef();
    const emailRef = useRef();
    const phoneNumberRef = useRef();
    const passwordRef = useRef();
    const confirmPasswordRef = useRef();
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);
    const history = useHistory();
   
    function handleRegister(e) {
        e.preventDefault()
        handleSubmit(e);
    }

    async function handleSubmit(e) {
        e.preventDefault();

        if (passwordRef.current.value !== confirmPasswordRef.current.value) {
            return setError("Parolele nu se potrivesc.");
        }

        setError("");
        setLoading(true);

        await axiosInstance.post('user', { 
                email: emailRef.current.value, 
                firstName: firstNameRef.current.value,
                lastName: lastNameRef.current.value,
                phoneNumber: phoneNumberRef.current.value,
                password: passwordRef.current.value 
            })
            .then(() => {
                history.push('/login');
            })
            .catch((error) => { 
                setError(error.response.data.message)
            })
            .finally(() => setLoading(false));
    }

    return (
        <Row className='full-height'>
            <Col xs={3} className='side-panel'>
                <div style={{height: '70%', textAlign: 'center'}} className='d-flex flex-column justify-content-around'>
                    <h1>AnticariApp</h1>

                    <h3>Cumpără sau postează propriile anunțuri de vânzare sau schimb de cărți chiar acum!</h3>
                </div>                
            </Col>

            <Col xs={9}>
                <Container className='mt-4'>
                    <h2 className='px-4 py-5'>Înregistrează-te</h2>
                    <h5 className='px-4 py-3'>Te rugăm să ne dai câteva detalii despre tine pentru a-ți putea crea profilul.</h5>
                    <hr/>

                    {error && <Alert variant="danger" className='mx-4'>{error}</Alert>}

                    <Form onSubmit={handleRegister}>
                        <Container>
                            <Row className='mt-2'>                                
                                <Col xs={12} md={6}>
                                    <Form.Group id="firstName">
                                        <Form.Label>Prenume</Form.Label>
                                        <Form.Control type="text" ref={firstNameRef} required />
                                    </Form.Group>
                                </Col>
                                <Col xs={12} md={6}>
                                    <Form.Group id="lastName">
                                        <Form.Label>Nume</Form.Label>
                                        <Form.Control type="text" ref={lastNameRef} required />
                                    </Form.Group>
                                </Col>
                            </Row>
                            <Row className='mt-2'>
                                <Col xs={12} md={6}>
                                    <Form.Group id="email" >
                                        <Form.Label>Email</Form.Label>
                                        <Form.Control type="email" ref={emailRef} required />
                                    </Form.Group>
                                </Col>
                                <Col xs={12} md={6}>
                                    <Form.Group id="phone" >
                                        <Form.Label>Telefon</Form.Label>
                                        <Form.Control type="text" ref={phoneNumberRef} required />
                                    </Form.Group>
                                </Col>
                            </Row>
                            <Row className='mt-3'>
                                <Col xs={12} md={6}>
                                    <Form.Group id="password" >
                                        <Form.Label>Parolă</Form.Label>
                                        <Form.Control type="password" ref={passwordRef} required />
                                    </Form.Group>
                                </Col>
                                <Col xs={12} md={6}>
                                    <Form.Group id="confirmPassword" >
                                        <Form.Label>Confirmă parola</Form.Label>
                                        <Form.Control type="password" ref={confirmPasswordRef} required />
                                    </Form.Group>
                                </Col>
                            </Row>
                            <Row>
                                <Col xs={6} md={3}>
                                    <Button variant='primary' disabled={loading} type="submit" className='mt-3'>
                                        Înregistrează-te
                                    </Button>
                                </Col>
                            </Row>
                        </Container>
                    </Form>

                    <div className="w-100 mt-2 px-4">
                        Ai deja un cont? <Link to="/login">Loghează-te.</Link>
                    </div>

                </Container>
            </Col>
        </Row>
    );
}

export default Register;
