import React, { useEffect, useState } from 'react';
import { Container, Row, Col, Form, Button, Badge } from 'react-bootstrap';
import NavMenu from '../NavMenu/NavMenu';
import Select from 'react-select';
import axiosInstance from '../../config/Axios';

const EditProfile = () => {
    const [userSettings, setUserSettings] = useState(null);
    const [preferredAuthors, setPreferredAuthors] = useState([]);
    const [preferredCategories, setPreferredCategories] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const crtUser = JSON.parse(localStorage.getItem('currentUser'));

        getUserSettings(crtUser.userId);
    }, [])

    async function getUserSettings(userId) {
        setLoading(true);
        await axiosInstance.get(`user/${userId}/settings`)
            .then(({ data }) => {
                formatAuthorsOptions(data);
                formatCategoriesOptions(data);
                
                setPreferredAuthors(getItemsRequest(data.preferredAuthors));
                setPreferredCategories(getItemsRequest(data.preferredCategories));

                setUserSettings(data);
            })
            .finally(() => setLoading(false));
    }

    const formatAuthorsOptions = (data) => {
        let authorOptions = [];

        data.existingAuthors.forEach((author) => {
            authorOptions.push({ value: author, label: author.name })
        });

        data.existingAuthors = authorOptions;
    }

    const formatCategoriesOptions = (data) => {
        let categoryOptions = [];

        data.existingCategories.forEach((category) => {
            categoryOptions.push({ value: category, label: category.name })
        });

        data.existingCategories = categoryOptions;
    }

    const getItemsResponse = (items) => {
        let values = []

        items.forEach((item) => {
            values.push(item.value);
        });

        return values;
    }

    const getItemsRequest = (items) => {
        let existingItems = []

        items.forEach((item) => {
            existingItems.push({value: item, label: item.name});
        })

        return existingItems;
    }

    const handleChange = (e) => {
        setUserSettings({ ...userSettings, [e.target.name]: e.target.value });
    };

    const handleSubmit = () => {
        setLoading(true);

        let newAuthors = getItemsResponse(preferredAuthors);
        let newCategories = getItemsResponse(preferredCategories);

        axiosInstance.put(`user/${userSettings.userId}/settings`, {
            idUser: userSettings.idUser,
            firstName: userSettings.firstName,
            lastName: userSettings.lastName,
            phoneNumber: userSettings.phoneNumber,
            city: userSettings.city,
            country: userSettings.country,
            streetName: userSettings.streetName,
            streetNumber: userSettings.streetNumber,
            zipCode: userSettings.zipCode,
            preferredAuthors: newAuthors,
            preferredCategories: newCategories
        })
        .then(() => setLoading(false))
        .finally(() => setLoading(false))
    }

    return (        
        <>
        <NavMenu />
        { userSettings &&
        <Container className='mt-5'>
            <h1 className='text-center'>Setările profilului dvs.</h1>
            <Form className='mt-5' onSubmit={handleSubmit}>
                <Container>
                <Row className='mt-2'>
                    <Col xs={12}>
                        <Form.Group>
                            <Form.Label style={{fontWeight: 'bold'}} htmlFor="email">Email</Form.Label>
                            <Form.Control type="text" name="email" id="email"
                                value={userSettings.email}
                                disabled />
                        </Form.Group>
                    </Col>
                </Row>
                <Row className='mt-2'>                    
                    <Col xs={12} md={6}>
                        <Form.Group>
                            <Form.Label style={{fontWeight: 'bold'}} htmlFor="firstName">Prenume</Form.Label>
                            <Form.Control type="text" name="firstName" id="firstName"
                                value={userSettings.firstName}
                                onChange={handleChange} 
                                required />
                        </Form.Group>
                    </Col>
                    <Col xs={12} md={6}>
                        <Form.Group>
                            <Form.Label style={{fontWeight: 'bold'}} htmlFor="lastName">Nume</Form.Label>
                            <Form.Control type="text" name="lastName" id="lastName"
                                value={userSettings.lastName}
                                onChange={handleChange}
                                required />
                        </Form.Group>
                    </Col>
                </Row>
                <Row className='mt-2'>                                
                    <Col xs={12} md={6}>
                        <Form.Group>
                            <Form.Label style={{fontWeight: 'bold'}} htmlFor="country">Țara</Form.Label>
                            <Form.Control type="text" name="country" id="country"
                                value={userSettings.country}
                                onChange={handleChange} 
                                required />
                        </Form.Group>
                    </Col>
                    <Col xs={12} md={6}>
                        <Form.Group>
                            <Form.Label style={{fontWeight: 'bold'}} htmlFor="city">Orașul</Form.Label>
                            <Form.Control type="text" name="city" id="city"
                                value={userSettings.city}
                                onChange={handleChange}
                                required />
                        </Form.Group>
                    </Col>
                </Row>
                <Row className='mt-2'>                                
                    <Col xs={12} md={6}>
                        <Form.Group>
                            <Form.Label style={{fontWeight: 'bold'}} htmlFor="streetName">Strada</Form.Label>
                            <Form.Control type="text" name="streetName" id="streetName"
                                value={userSettings.streetName}
                                onChange={handleChange} 
                                required />
                        </Form.Group>
                    </Col>
                    <Col xs={12} md={6}>
                        <Form.Group>
                            <Form.Label style={{fontWeight: 'bold'}} htmlFor="streetNumber">Numărul</Form.Label>
                            <Form.Control type="number" name="streetNumber" id="streetNumber"
                                value={userSettings.streetNumber}
                                onChange={handleChange}
                                required />
                        </Form.Group>
                    </Col>
                </Row>
                <Row className='mt-2'>                                
                    <Col xs={12} md={6}>
                        <Form.Group>
                            <Form.Label style={{fontWeight: 'bold'}} htmlFor="zipCode">Cod poștal</Form.Label>
                            <Form.Control type="text" name="zipCode" id="zipCode"
                                value={userSettings.zipCode}
                                onChange={handleChange} 
                                required />
                        </Form.Group>
                    </Col>
                    <Col xs={12} md={6}>
                        <Form.Group>
                            <Form.Label style={{fontWeight: 'bold'}} htmlFor="phoneNumber">Telefon</Form.Label>
                            <Form.Control type="text" name="phoneNumber" id="phoneNumber"
                                value={userSettings.phoneNumber}
                                onChange={handleChange}
                                required />
                        </Form.Group>
                    </Col>
                </Row>
                <Row className='mt-4'>
                    <Form.Label style={{fontWeight: 'bold'}}>
                        Selectați autorii preferați
                    </Form.Label>
                    <Select
                        defaultValue={preferredAuthors}
                        isMulti
                        name='preferredAuthors'
                        options={userSettings.existingAuthors}
                        onChange={setPreferredAuthors}
                        className='basic-multi-select'
                        classNamePrefix='select'
                    />
                </Row>
                <Row className='mt-4'>
                    <Form.Label style={{fontWeight: 'bold'}}>
                        Selectați categoriile de cărți preferate
                    </Form.Label>
                    <Select
                        defaultValue={preferredCategories}
                        isMulti
                        name='preferredCategories'
                        options={userSettings.existingCategories}
                        onChange={setPreferredCategories}
                        className='basic-multi-select'
                        classNamePrefix='select'
                    />
                </Row>
                <Row className='mt-4 h4'>
                    <Col xs={12} md={4}>
                        Articole vândute: <Badge pill bg='primary'>{userSettings.statistics.soldItems}</Badge>
                    </Col>
                    <Col xs={12} md={4}>
                        Cărți citite: <Badge pill bg='warning'>{userSettings.statistics.readBooks}</Badge>
                    </Col>
                    <Col xs={12} md={4}>
                        Rating mediu: <Badge pill bg='success'>{userSettings.statistics.avgRating ? userSettings.statistics.avgRating : "N/A"}</Badge>
                    </Col>
                </Row>
                <Row>
                    <Col xs={6} md={3}>
                        <Button variant='primary' disabled={loading} type="submit" className='mt-3'>
                            Salvează
                        </Button>
                    </Col>
                </Row>
                </Container>
            </Form>
        </Container>}
        </>
    )
}

export default EditProfile;
