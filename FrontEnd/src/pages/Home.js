import React , { useState, useEffect } from 'react'
import { Row, Col } from 'react-bootstrap'
import ProductCard from '../components/Product/ProductCard'
import axios from 'axios'

const Home = () => {

  const [products, setProducts] = useState([])

  useEffect(() => {

    const sendRequest = async () => {
      const response = await axios.get('http://localhost:5001/api/products')
      setProducts(response.data.result)
    }

    sendRequest()
  },[])

  return (
    <div>
      <h1>محصولات</h1>
      <Row>
        {products.map((item) => {
          return (
            <Col key={item.productId} sm={12} md={6} lg={4}>
              <ProductCard product={item} />
            </Col>
          )
        })}
      </Row>
    </div>
  )
}

export default Home
