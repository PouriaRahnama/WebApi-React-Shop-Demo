import React, { useState, useEffect } from 'react'
import { Row, Col, ListGroup, Image, Button, Card } from 'react-bootstrap'
import { useParams, useLocation } from 'react-router-dom'
import axios from 'axios'

const getDataFromLs = () => {
  const data = localStorage.getItem('ProductCarts');
  if (data) {
    return JSON.parse(data)
  } else {
    return [];
  }
}

const Cart = () => {
  const { id } = useParams()
  const [cartItems, setCartItems] = useState(getDataFromLs())

  useEffect(() => {
    const sendRequest = async () => {
      const response = await axios.get(
        `http://localhost:5001/api/products/${id}`
      )

      const { result } = response.data
      const exist = cartItems.find((element) => element.productId === result.productId);

      if (exist == null) {
        setCartItems([...cartItems, { ...result, qty: 1 }])
      }
      else {
        setCartItems(cartItems.map((element) => element.productId === exist.productId ? { ...exist, qty: exist.qty + 1 } : element)
        )
      }
    }
    if (id != null)
      sendRequest()
  }, [id])

  useEffect(() => {
    localStorage.setItem('ProductCarts', JSON.stringify(cartItems))
  }, [cartItems])

  const deleteCart = (number) => {
    const exist = cartItems.find((element) => element.productId === number);
    if (exist.qty === 1) {
      setCartItems(cartItems.filter((element) => element.productId !== exist.productId));

    } else {
      setCartItems(
        cartItems.map((element) => element.productId === number ? { ...exist, qty: exist.qty - 1 } : element)
      )
    }
  }
  

  return (
    <>
      <h2>Cart</h2>
      {
        cartItems.length === 0 ?
          <div className="empty-price">The shopping cart is empty.</div> :
          <div className="show-price">You have {cartItems.length} product in the cart.  </div>
      }
      <div>
        <Row>
          <Col md={8}>
            <ListGroup variant="flush">
              {cartItems.map((item) => (
                <ListGroup.Item key={item.productId}>
                  <Row>
                    <Col md={2}>
                      <Image src={item.imageURL} alt={item.name} fluid rounded />
                    </Col>
                    <Col md={3}>{item.name}</Col>
                    <Col md={2}>{item.price}</Col>
                    <Col md={2}>{item.qty}</Col>
                    <Col md={2}>
                      <Button
                        type="button"
                        variant="light"
                        onClick={() => deleteCart(item.productId)}
                      >
                        <i className="fa fa-trash"></i>
                      </Button>
                    </Col>
                  </Row>
                </ListGroup.Item>
              ))}
            </ListGroup>
          </Col>
          <Col md={4}>
            <Card>
              <ListGroup variant="flush">
                <ListGroup.Item>
                  Total: {cartItems.reduce((acc, item) => acc + item.price * item.qty, 0)}
                </ListGroup.Item>
              </ListGroup>
            </Card>
          </Col>
        </Row>
      </div>
    </>
  )
}

export default Cart
