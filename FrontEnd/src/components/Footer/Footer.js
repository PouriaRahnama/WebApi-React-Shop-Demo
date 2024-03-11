import React from 'react'
import { Container, Row, Col } from 'react-bootstrap'

const Footer = () => {
  return (
    <footer style={{background: '#3949ab', marginTop:'2.7%'}}>
      <Container>
        <Row>
          <Col className="text-center text-light p-3">
            Copyright © 2024 Inc. All rights reserved.
             </Col>
        </Row>
      </Container>
    </footer>
  )
}

export default Footer
