import React, { useEffect, useState } from 'react'
import { LinkContainer } from 'react-router-bootstrap'
import { Container, Navbar, Nav, Dropdown, DropdownButton } from 'react-bootstrap'
import { Link } from 'react-router-dom'
import './Header.css'
import axios from 'axios'

const Header = () => {

  const [categories, setCategories] = useState([])
  useEffect(() => {

    const sendRequest = async () => {
      const response = await axios.get('http://localhost:5001/api/products/Category')

      setCategories(response.data.result)
    }

    sendRequest()
  }, [])


  return (
    <header>
      <Navbar className="nav-bg" variant="dark">
        <Container>
          <LinkContainer to="/">
            <Navbar.Brand>FC Market</Navbar.Brand>
          </LinkContainer>
          <DropdownButton title="Category">
            {
              categories.map((item) =>
                <Link key={item.categoryId} to={`/Category/${item.title}`}>
                  <Dropdown.Item as="div"  href="#">{item.title}</Dropdown.Item>
                </Link>
              )
            }
          </DropdownButton>
          <Nav>
            <LinkContainer to="/cart">
              <Nav.Link>
                <i className="fa fa-shopping-cart"></i>
              </Nav.Link>
            </LinkContainer>
            <LinkContainer to="/account">
              <Nav.Link>
                <i className="fa fa-user"></i>
              </Nav.Link>
            </LinkContainer>
          </Nav>
        </Container>
      </Navbar>
    </header>
  )
}

export default Header
