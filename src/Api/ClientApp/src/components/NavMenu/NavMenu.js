import React from 'react';
import { Navbar, Nav } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faHouse, faMagnifyingGlass, faListCheck, faCirclePlus } from '@fortawesome/free-solid-svg-icons';

const NavMenu = () => {

    return (
        <Navbar bg="dark" variant="dark" expand="lg" sticky="top" className='px-5 height-5'>
            <Navbar.Brand href="/">AnticariApp</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ml-auto">                        
                        <Nav.Link href="/">
                            <FontAwesomeIcon icon={faHouse} className='text-warning mx-1' />
                            <span>Acasă</span>
                        </Nav.Link>
                    </Nav>
                    <Nav className="ml-auto">
                        <Nav.Link href="/search">
                            <FontAwesomeIcon icon={faMagnifyingGlass} className='text-light mx-1' />
                            <span>Căutați</span>
                        </Nav.Link>
                    </Nav>
                    <Nav className="ml-auto">
                        <Nav.Link href="/wishlist">
                            <FontAwesomeIcon icon={faListCheck} className='text-success mx-1' />
                            <span>Wishlist</span>
                        </Nav.Link>
                    </Nav>
                    <Nav className="ml-auto">
                        <Nav.Link href="/add-posting">
                            <FontAwesomeIcon icon={faCirclePlus} className='text-primary mx-1' />
                            <span>Adăugați o postare</span>
                        </Nav.Link>
                    </Nav>
                </Navbar.Collapse>
        </Navbar>
    )
}

export default NavMenu;