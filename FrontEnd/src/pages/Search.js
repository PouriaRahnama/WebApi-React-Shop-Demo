import React, { useState, useEffect } from 'react'
import { Row, Col } from 'react-bootstrap'
import ProductCard from '../components/Product/ProductCard'
import axios from 'axios'
import { useParams } from 'react-router-dom'

const Search = () => {

    const [products, setProducts] = useState([])
    const [category, setCategory] = useState({})
    const { title } = useParams()

    useEffect(() => {

        const sendRequest = async () => {
            const response = await 
            axios.get(
            `http://localhost:5001/api/products/GetProductsByCategoryTitle?CategoryTitle=${title}`)

            setProducts(response.data.result.productDto)
            setCategory(response.data.result.categoryDto)
        }

        sendRequest()
    }, [title])

    return (
        <div>
            <h1>Search For : {category && category.title}</h1>
            <Row>
                {products && products.map((item) => {
                    return (
                        <Col key={item.productId} sm={12} md={6} lg={4}>
                            <ProductCard product={item} />
                        </Col>
                    )
                })}
            </Row>
        </div>
    );
}


export default Search;
