import React from 'react';
import { Navbar, Nav } from 'react-bootstrap';

const NavMenu = () => {

    return (
        <Navbar bg="dark" variant="dark" expand="lg" sticky="top" className='px-5'>
            <Navbar.Brand href="/">AnticariApp</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ml-auto">
                        <Nav.Link href="/">Acasă</Nav.Link>
                    </Nav>
                </Navbar.Collapse>
        </Navbar>
    )
}

export default NavMenu;