import React,{useState,useEffect} from 'react'
import { Link, useParams,useNavigate } from 'react-router-dom'
import { Row, Col, Image, ListGroup, Button } from 'react-bootstrap'
import axios from 'axios'


const Product = () => {
  const { id } = useParams()
  const navigate = useNavigate();

  const [product, setProduct] = useState({})

  useEffect(() => {

    const sendRequest = async () => {
      const response = await axios.get(
        `http://localhost:5001/api/products/${id}`
      )
      setProduct(response.data.result)
    }
    sendRequest()
  },[id])

  const addToCartHandler = () => {
    navigate(`/cart/${id}`)
  }

  return (
    <div>
      <Link to="/" className="btn btn-light my-3">
      come back to main page
      </Link>
      <Row>
        <Col md={6}><Image src={product.imageURL} fliud="true" /></Col>
        <Col md={3}>
          <ListGroup variant="flush">
            <ListGroup.Item><h3>{product.name}</h3></ListGroup.Item>
            <ListGroup.Item>{product.price}</ListGroup.Item>
            <ListGroup.Item>{product.description}</ListGroup.Item>
          </ListGroup>
        </Col>
        <Col md={3}>
          <ListGroup variant="flush">
            <ListGroup.Item>
              <Button  onClick={addToCartHandler}
               className="btn-block"
                type="button">
                Add to cart
              </Button>
            </ListGroup.Item>
          </ListGroup>
        </Col>
      </Row>
    </div>
  )
}

export default Product
